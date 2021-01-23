    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web;
    
    namespace iMax_WeSite.app.Objects.DataTables
    {
        public class DataTable
        {
            public DataTable()
            {
            }
            public int sEcho { get; set; }
            public int iTotalRecords { get; set; }
            public int iTotalDisplayRecords { get; set; }
            public string iTotalValue { get; set; } //Somatoria total do valor
            public string iTotalFilteredValue { get; set; } //Somatoria parcial do valor
            public List<List<string>> aaData { get; set; }
            public string sColumns { get; set; }
            
            public void Import(string[] properties)
            {
                sColumns = string.Empty;
                for (int i = 0; i < properties.Length; i++)
                {
                    sColumns += properties[i];
                    if (i < properties.Length - 1)
                        sColumns += ",";
                }
            }
        }
        public class DataTableParser<T>
        {
            private const string INDIVIDUAL_SEARCH_KEY_PREFIX = "sSearch_";
            private const string INDIVIDUAL_SORT_KEY_PREFIX = "iSortCol_";
            private const string INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX = "sSortDir_";
            private const string DISPLAY_START = "iDisplayStart";
            private const string DISPLAY_LENGTH = "iDisplayLength";
            private const string ECHO = "sEcho";
            private const string SEARCH = "sSearch";
            private const string ASCENDING_SORT = "asc";
            private IQueryable<T> _queriable;
            private readonly Dictionary<string, object> _tableParams;
            private readonly Type _type;
            private readonly System.Reflection.PropertyInfo[] _properties;
            public DataTableParser(Dictionary<string, object> tableParams, IQueryable<T> queriable)
            {
                _queriable = queriable;
                _tableParams = tableParams;
                _type = typeof(T);
                _properties = _type.GetProperties();
            }
    
            public DataTable Parse()
            {
                var list = new DataTable();
                list.Import(_properties.Select(x => x.Name).ToArray());
    
                list.sEcho = (int)_tableParams[ECHO];
    
                list.iTotalRecords = _queriable.Count();
    
                ApplySort();
    
                int skip = 0, take = list.iTotalRecords;
                if (_tableParams.ContainsKey(DISPLAY_START))
                    skip = (int)_tableParams[DISPLAY_START];
                if (_tableParams.ContainsKey(DISPLAY_LENGTH))
                    take = (int)_tableParams[DISPLAY_LENGTH];
    
                //tenho de segregar para mostrar o filtrado 
                list.aaData = _queriable.Where(ApplyGenericSearch)
                                        .Where(IndividualPropertySearch)
                                        .Skip(skip)
                                        .Take(take)
                                        .Select(SelectProperties)
                                        .ToList();
    
                //tenho de segregar para mostrar o filtrado geral
                list.iTotalDisplayRecords = _queriable.Where(ApplyGenericSearch)
                                                        .Where(IndividualPropertySearch)
                                                        .Select(SelectProperties)
                                                        .Count();
                return list;
            }
            private void ApplySort()
            {
                foreach (string key in _tableParams.Keys.Where(x => x.StartsWith(INDIVIDUAL_SORT_KEY_PREFIX)))
                {
                    int sortcolumn = (int)_tableParams[key];
                    if (sortcolumn < 0 || sortcolumn >= _properties.Length)
                        break;
    
                    string sortdir = _tableParams[INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX + key.Replace(INDIVIDUAL_SORT_KEY_PREFIX, string.Empty)].ToString();
    
                    var paramExpr = Expression.Parameter(typeof(T), "val");
                    var propertyExpr = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(paramExpr, _properties[sortcolumn]), typeof(object)), paramExpr);
    
    
                    if (string.IsNullOrEmpty(sortdir) || sortdir.Equals(ASCENDING_SORT, StringComparison.OrdinalIgnoreCase))
                        _queriable = _queriable.OrderBy(propertyExpr);
                    else
                        _queriable = _queriable.OrderByDescending(propertyExpr);
                }
            }
    
            private Expression<Func<T, List<string>>> SelectProperties
            {
                get
                {
                    return value => _properties.Select
                                                (
                                                    prop => (prop.GetValue(value, new object[0]) ?? string.Empty).ToString()
                                                )
                                                .ToList();
                }
            }
    
            private Expression<Func<T, bool>> IndividualPropertySearch
            {
                get
                {
                    var paramExpr = Expression.Parameter(typeof(T), "val");
                    Expression whereExpr = Expression.Constant(true); // default is val => True
                    foreach (string key in _tableParams.Keys.Where(x => x.StartsWith(INDIVIDUAL_SEARCH_KEY_PREFIX)))
                    {
                        int property = -1;
    
                        if (!int.TryParse(key.Replace(INDIVIDUAL_SEARCH_KEY_PREFIX, string.Empty), out property) || property >= _properties.Length || string.IsNullOrEmpty(_tableParams[key].ToString())) 
                            continue; // ignore if the option is invalid
    
                        string query = _tableParams[key].ToString().ToLower();
    
                        var toStringCall = Expression.Call(
                                            Expression.Call(
                                                Expression.Property(paramExpr, _properties[property]), "ToString", new Type[0]),
                                                                    typeof(string).GetMethod("ToLower", new Type[0]));
    
                        whereExpr = Expression.And(whereExpr,
                                                    Expression.Call(toStringCall,
                                                                    typeof(string).GetMethod("Contains", BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase),
                                                                    Expression.Constant(query)));
    
                    }
                    return Expression.Lambda<Func<T, bool>>(whereExpr, paramExpr);
                }
            }
    
            private Expression<Func<T, bool>> ApplyGenericSearch
            {
                get
                {
                    if (!_tableParams.ContainsKey(SEARCH) || _properties.Length == 0)
                        return x => true;
    
                    string search = _tableParams[SEARCH].ToString();
    
                    if (String.IsNullOrEmpty(search))
                        return x => true;
    
                    var searchExpression = Expression.Constant(search.ToLower());
                    var paramExpression = Expression.Parameter(typeof(T), "val");
    
                    var propertyQuery = (from property in _properties
                                            let tostringcall = Expression.Call(
                                                                Expression.Call(
                                                                    Expression.Property(paramExpression, property), "ToString", new Type[0]),
                                                                    typeof(string).GetMethod("ToLower", new Type[0]))
                                            select Expression.Call(tostringcall, typeof(string).GetMethod("Contains"), searchExpression)).ToArray();
    
                    Expression compoundExpression = propertyQuery[0];
    
                    for (int i = 1; i < propertyQuery.Length; i++)
                        compoundExpression = Expression.Or(compoundExpression, propertyQuery[i]);
    
                    return Expression.Lambda<Func<T, bool>>(compoundExpression, paramExpression);
                }
            }
    
        }
    
    }
