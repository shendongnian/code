    string xml = @"<?xml version=""1.0""?>
    <results>
        <results>
                <field>2</field>
                <something>0</something>
                <name>alex</name>
        </results>
        <results>
                <field>0</field>
                <something>0</something>
                <name>jack</name>
        </results>
        <results>
                <field>2</field>
                <something>1</something>
                <name>heath</name>
        </results>
        <results>
                <field>0</field>
                <something>0</something>
                <name>blake</name>
        </results>
    </results>";
    
    StringBuilder sb = new StringBuilder();
    using (var p = ChoXmlReader.LoadText(xml))
    {
    	using (var w = new ChoCSVWriter(sb)
    		.WithFirstLineHeader()
    		)
    		w.Write(p);
    }
    
    Console.WriteLine(sb.ToString());
