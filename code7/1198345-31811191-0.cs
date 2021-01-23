    using System; 
    using System.Collections.Generic; 
    using System.Data.Entity; 
    using System.Data.SqlClient; 
    using System.Linq; 
    using System.Transactions; 
     
    namespace TransactionsExamples 
    { 
        class TransactionsExample 
        { 
            static void StartOwnTransactionWithinContext() 
            { 
                using (var context = new BloggingContext()) 
                { 
                    using (var dbContextTransaction = context.Database.BeginTransaction()) 
                    { 
                        try 
                        { 
                            context.Database.ExecuteSqlCommand( 
                                @"UPDATE Blogs SET Rating = 5" + 
                                    " WHERE Name LIKE '%Entity Framework%'" 
                                ); 
     
                            var query = context.Posts.Where(p => p.Blog.Rating >= 5); 
                            foreach (var post in query) 
                            { 
                                post.Title += "[Cool Blog]"; 
                            } 
     
                            context.SaveChanges(); 
     
                            dbContextTransaction.Commit(); 
                        } 
                        catch (Exception) 
                        { 
                            dbContextTransaction.Rollback(); 
                        } 
                    } 
                } 
            } 
        } 
    }
