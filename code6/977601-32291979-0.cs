    public partial class V_CUSTOMER_GLOBALTableAdapter
    {
        public void SetBindByName(bool value = true)
        {
            foreach (Oracle.DataAccess.Client.OracleCommand cmd in this.CommandCollection)
            {
                cmd.BindByName = value;
            }
        }
    }
