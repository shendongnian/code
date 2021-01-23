                public class DoEqual
                	{
                		
                	}
                    public interface ICanAddWhereValue
                    {
                        ICanAddWhereOrRun IsEqualTo(object value);
                        ICanAddWhereOrRun IsNotEqualTo(object value);
                		IBothEqual BothEqual ( object value );
                    }
                
                	public interface IBothEqual
                	{
                		DoEqual Excute();
                	}
                
                
                    public interface ICanAddWhereOrRun
                    {
                        ICanAddWhereValue Where(string columnName);
                        bool RunNow();
                	    DoEqual Excute();
                    }
                
                 public interface ICanAddCondition
                    {
                        ICanAddWhereValue Where(string columnName);
                        bool AllRows();
                    }
            
            namespace BuildAFluentInterface
            {
                public class WhereCondition
                {
                    public enum ComparisonMethod
                    {
                        EqualTo,
                        NotEqualTo
                    }
            
                    public string ColumnName { get; private set; }
                    public ComparisonMethod Comparator { get; private set; }
                    public object Value { get; private set; }
            
                    public WhereCondition(string columnName, ComparisonMethod comparator, object value)
                    {
                        ColumnName = columnName;
                        Comparator = comparator;
                        Value = value;
                    }
                }
            }
        
        using System.Collections.Generic;
        
        namespace BuildAFluentInterface
        {
            public class DeleteQueryWithoutGrammar
            {
                private readonly string _tableName;
                private readonly List<WhereCondition> _whereConditions = new List<WhereCondition>();
        
                private string _currentWhereConditionColumn;
        
                // Private constructor, to force object instantiation from the fluent method(s)
                private DeleteQueryWithoutGrammar(string tableName)
                {
                    _tableName = tableName;
                }
        
                #region Initiating Method(s)
        
                public static DeleteQueryWithoutGrammar DeleteRowsFrom(string tableName)
                {
                    return new DeleteQueryWithoutGrammar(tableName);
                }
        
                #endregion
        
                #region Chaining Method(s)
        
                public DeleteQueryWithoutGrammar Where(string columnName)
                {
                    _currentWhereConditionColumn = columnName;
        
                    return this;
                }
        
                public DeleteQueryWithoutGrammar IsEqualTo(object value)
                {
                    _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.EqualTo, value));
        
                    return this;
                }
        
                public DeleteQueryWithoutGrammar IsNotEqualTo(object value)
                {
                    _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.NotEqualTo, value));
        
                    return this;
                }
        
                #endregion
        
                #region Executing Method(s)
        
                public void AllRows()
                {
                    ExecuteThisQuery();
                }
        
                public void RunNow()
                {
                    ExecuteThisQuery();
                }
        
                #endregion
        
                private void ExecuteThisQuery()
                {
                    // Code to build and execute the delete query
                }
            }
        }
    <br>
    In Main Test with 
    public class myclass
    {
    private static void Main(string[] args)
    		{
    DoEqual x3 =
    				DeleteQueryWithGrammar.DeleteRowsFrom("Account")
    					.Where("Admin")
    					.IsNotEqualTo("Admin")
    					.Where("Admin")
    					.BothEqual("X")
    					.Excute();
    }
    }
