      // I had the problem that the program didn't find the specific class
      // This is the code that I used and it helped me resolve the exception by entering the namespace also
         
         // the s is the string
           Type objType = Type.GetType("Namespace." + s);
            object obj = Activator.CreateInstance(objType);
            
            MethodInfo Method = objType.GetMethod("showData");
            object Value = Method.Invoke(obj,null);
            richTextBox1.Text = Value.ToString();
