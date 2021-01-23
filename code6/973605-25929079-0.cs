    public static class CommonUtilities
    {
        public static List<string> GetCheckboxSelectedValue(FormCollection frm, string checkboxname, string value)
        {
            List<string> retls = new List<string>();
            var fileIds = frm[value].Split(',');
            var selectedIndices = frm[checkboxname].Replace("true,false", "true").Split(',').Select((item, index) => 
                new {
                        item= item,
                        index= index
                    }).Where(row=>row.item =="true")
                .Select(row => row.index).ToArray();
            if (selectedIndices.Count() > 0)
            {
                retls.AddRange(selectedIndices.Select(index => fileIds[index]));
            }
            return retls;
        }
    }
