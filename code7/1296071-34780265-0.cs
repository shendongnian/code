    namespace IMS.Model
     {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    using System.Reflection;
    using System.Linq;
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [Serializable]
    public class MappingAttribute : Attribute
    {
        public string ColumnName = null;
    }
    public partial class IMS_Controller<IMS_WorkingTable> where IMS_WorkingTable : new()
    {
        private readonly string tablename;
        private readonly string keyname;
        protected IMS_Controller(string tablename, string keyname)
        {
            this.tablename = tablename;
            this.keyname = keyname;
        }
        public string _tablename { get { return tablename; } }
        public string _keyname { get { return keyname; } }
        public IEnumerable<IMS_WorkingTable> _recordset;
        IMS_WorkingTable MapToClass(IDataRecord record)
        {
            IMS_WorkingTable returnedObject = Activator.CreateInstance<IMS_WorkingTable>();
            List<PropertyInfo> modelProperties = returnedObject.GetType().GetProperties().OrderBy(p => p.MetadataToken).ToList();
            for (int i = 0; i < modelProperties.Count; i++)
                try
                {
                    modelProperties[i].SetValue(returnedObject, Convert.ChangeType(record.GetValue(i), modelProperties[i].PropertyType), null);
                }
                catch { }
            return returnedObject;
        }
        public void gets(string keyval)
        {
            string sql = string.Format("SELECT * from {0} where {1}='{2}'", _tablename, _keyname, keyval);
            getIt(sql);
        }
        public string gets(string keyval, string where)
        {
            string sql = string.Format("SELECT * from {0} where {1}='{2}' {3}", _tablename, _keyname, keyval, where);
            try
            {
                getIt(sql);
                return "Sucess: " + sql;
            }
            catch
            {
                return "Error: " + sql;
            }
        }
        public void sets(string keyval, string field, string value)
        {
            setIt(keyval, field, value);
        }
        private void getIt(string strSQL)
        {
            var table = new List<IMS_WorkingTable>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMS"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(strSQL, con))
                {
                    IMS_WorkingTable t = new IMS_WorkingTable();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            t = MapToClass((IDataRecord)reader);
                            table.Add(t);
                        }
                        _recordset = table;
                        reader.Close();
                        reader.Dispose();
                    }
                    cmd.Dispose();
                }
                con.Close();
                con.Dispose();
            }
        }
        private void setIt(string keyval, string field, string value)
        {
            var products = new List<IMS_WorkingTable>();
            var strSQL = string.Format("update {0} set {1} = '{2}' where {3}='{4}'", _tablename, field, value, _keyname, keyval);
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMS"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
    }
    }
    namespace IMS.Model
    {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class IMM_StoreOrder
    {
        [Mapping(ColumnName = "StoreOrderID")]
        [Key]
        public Guid StoreOrderID { get; set; }
        [Mapping(ColumnName = "StoreUserId")]
        public Guid StoreUserId { get; set; }
        [Mapping(ColumnName = "OrderID")]
        [Required]
        [StringLength(128)]
        public string OrderID { get; set; }
        [Mapping(ColumnName = "OrderDate")]
        public DateTime OrderDate { get; set; }
        [Mapping(ColumnName = "Status")]
        [StringLength(256)]
        public string Status { get; set; }
        [Mapping(ColumnName = "DeletedFlag")]
        public bool DeletedFlag { get; set; }
        [Mapping(ColumnName = "IPAddress")]
        [StringLength(50)]
        public string IPAddress { get; set; }
    }
    public partial class IMS_StoreOrderController : IMS_Controller<IMM_StoreOrder>
    {
        public IMS_StoreOrderController() : base("IMM_StoreOrder", "StoreOrderID") { }
    }
    }
