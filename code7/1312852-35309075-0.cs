    catch (SqlException ex)
    {  
        switch (ex.Errors[0].Number)
        {
            case 547: // Foreign Key violation
                string s = ex.Message;
                s = s.Substring(s.IndexOf("column "));
                string[] array = s.Split('.');
                s = array[0].Substring(array[0].IndexOf('\''));               
                break;
        }
    }
