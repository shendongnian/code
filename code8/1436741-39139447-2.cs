		public void BindMyData()
        {
            IEnumerable<patient> patients = JsonConvert.DeserializeObject<IEnumerable<patient>>(resultAsJson);
            datagrid.DataSource = patients;
        }
