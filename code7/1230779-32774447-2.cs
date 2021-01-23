    public class PrependTextInterceptor : DbCommandInterceptor
    {        
        const string table = "MyTable";
        const string column = "Comments";
        public override void NonQueryExecuting(DbCommand command, System.Data.Entity.Infrastructure.Interception.DbCommandInterceptionContext<int> interceptionContext)
        {
            command.CommandText = Regex.Replace(command.CommandText, 
                                  string.Format(@"(?i:(?<=^UPDATE \[.+\]\.\[{0}\]\r\nSET .* \[{1}\] = ).+?(?=(,|\r\n)))", table, column), "$& + " + column);            
            base.NonQueryExecuting(command, interceptionContext);            
        }
    }
    //Usage
    DbInterception.Add(new PrependTextInterceptor());
    //after this every time you set the Comments property 
    //it will be understood as prepending    
    item.Comments = displayComment.Append("Hi")
                                  .Append(Environment.NewLine).ToString();
