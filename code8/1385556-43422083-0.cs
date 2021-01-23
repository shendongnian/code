    public class MyDataAccessClass {
        private IDbConnectionFactory connectionFactory;
    
        public MyDataAccessClass(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }
    
        public object GetData(string nuf) {
            using (var connection = connectionFactory.CreateConnection()) {
                connection.Open();
                var query = "SELECT mi.* from fromTable mi where 1=1 " 
                            + (string.IsNullOrEmpty(nuf) ? "" : " and mi.NUF != @nuf")
                            + " and mi.Category<>'TES' and mi.Category<>'CVD'"
                using(var command = connection.CreateCommand()){
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    if(!string.IsNullOrEmpty(nuf)) {
                        var parameter = command.CreateParameter();
                        parameter.ParameterName = "@nuf";
                        parameter.Value = nuf;
    
                        command.Parameters.Add(parameter);
                    }
            
                    Debug.WriteLine(command.CommandText);
            
                    var dr = command.ExecuteReader();
                    //...other code removed for brevity
                }
            }
        }
    }
