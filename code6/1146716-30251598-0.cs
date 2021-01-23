    public class MyInitializer : CreateDatabaseIfNotExists<MyContext>
    {
      protected override void Seed(MyContext context)
      {
        query = "CREATE VIEW [ schema_name . ] view_name [ (column [ ,...n ] ) ] 
                [ WITH <view_attribute> [ ,...n ] ] 
                AS select_statement 
                 [ WITH CHECK OPTION ] 
                 [ ; ]
    
                <view_attribute> ::= 
                {
                    [ ENCRYPTION ]
                    [ SCHEMABINDING ]
                    [ VIEW_METADATA ]     
                } ";
        
        context.Database.SqlCommand(query);
      }
    }
