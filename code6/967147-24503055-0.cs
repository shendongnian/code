    Color c = Color.FromArgb(169, 170, 171, 172);
    Console.WriteLine(c); //Color [A=169, R=170, G=171, B=172]
    string colorStr = JsonConvert.SerializeObject(c);
    Console.WriteLine(colorStr); //"169, 170, 171, 172"
    Color c1 = JsonConvert.DeserializeObject<Color>(colorStr);
    Console.WriteLine(c1); //Color [A=169, R=170, G=171, B=172]
