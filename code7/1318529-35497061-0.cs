    var lines = File.ReadAllLines(filename);
    var columns =  lines[0].Split(';');
    
    var xmlFile = new XElement("Rows",
    	lines.Skip(1).Select(line => new XElement("Row",
    		line.Split(';')
    		.Where(s=> !string.IsNullOrEmpty(s))
    		   .Select((column, index) => new XElement(columns[index].Replace("/", "_"), column)))));
    xmlFile.Save(ouputfile);
