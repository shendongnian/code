        public async Task<IActionResult> Export(string type)
        {
            string _OuputType = type.ToLower().Trim();  
            string _delimiter = _OuputType.Contains("csv") ? ";" : String.Empty;
            _delimiter = _OuputType.Contains("txt") ? "" : _delimiter;             
            IEnumerable<Material> data = await _context.Material.Include(m => m.Unit).ToListAsync(); 
            StringBuilder str = new StringBuilder();
            //file name
            string fileName = "Material-" + DateTime.Now.ToString("dd_MM_yyyy-H_mm_ss");
            //head
            str.Append("Name" + _delimiter + "\t");
            str.Append("AutoPlan" + _delimiter + "\t");
            str.Append("QuantityMinStock" + _delimiter + "\t");
            str.Append("QuantityMaxStock" + _delimiter + "\t");
            str.Append("QuantityPurchase" + _delimiter + "\t");
            str.Append("Unit" + _delimiter + "\t");
            str.Append("\r\n");
            //data
            foreach (Material m in data)
            {
                str.Append(m.id + _delimiter + "\t");
                str.Append(m.Name + _delimiter + "\t");
                str.Append(m.AutoPlan + _delimiter + "\t");
                str.Append(m.QuantityMinStock + _delimiter + "\t");
                str.Append(m.QuantityMaxStock + _delimiter + "\t");
                str.Append(m.QuantityPurchase + _delimiter + "\t");
                str.Append(m.Unit.LocalizedCode + _delimiter + "\t");
                str.Append("\r\n");
            }    
            //   int codepage = _cultureDataProvider.GetAnsiCodePage(Configuration.UserCulture); == This is my service to get code page (example: 1250, or 1252 etc...)
            Encoding encode = Encoding.GetEncoding(_cultureDataProvider.GetAnsiCodePage(Configuration.UserCulture));
            byte[] bytes = encode.GetBytes(str.ToString());
      
            if (_OuputType == "txt"){return File(bytes, "text/plain", fileName + ".txt");}
            return File(bytes, "application/msexcel", fileName + ".csv");
       }
