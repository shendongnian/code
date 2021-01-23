    try
        {
            query.CommandText = "alter table publisher DROP COLUMN @col ";       
            query.Parameters.AddWithValue("@col", columnName);
            int result=query.ExecuteNonQuery();
            transaction.Commit();
            if(result>0)
            Console.WriteLine("column deleted successfully");
            else
            Console.WriteLine("successfully committed to database");
        }
