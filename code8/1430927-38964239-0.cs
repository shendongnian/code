    var arr = System.Text.Encoding.UTF8.GetBytes(strPost);
    
    objRequest.ContentLength = arr.Length;
    
        try
        {
            using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
            {
                myWriter.Write(arr, 0, arr.Length);
            }
        }
