    for (int i = 0; i < runCount; i++)      
    {
        int milliseconds = 50;
        System.Threading.Thread.Sleep(milliseconds);  
    
        string path = Request.PhysicalApplicationPath + @"\test\test\test\foo" + i + ".txt";
        StringBuilder sb = new StringBuilder();
        sb.Append(i);
        System.IO.File.WriteAllText(path, sb.ToString());
    }
}
