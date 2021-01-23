        public void CreateLog(object parameters)
        {
            foreach(var property in parameters.GetType().GetProperties())
            {
                WriteLog(string.Format("{0} - {1}",property.Name, property.GetValue(parameters)));
            }
        }
