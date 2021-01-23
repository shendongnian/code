        public IEnumerable<T> Query<T>(string sqlQuery, object parameters = null)
        {
            this.activeConnection.Open();
            var result = this.activeConnection
                .Query<T>(sqlQuery, parameters);
            this.activeConnection.Close();
            return result;
        }
