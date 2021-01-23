    static void Main(string[] args)
        {
            ProjectContext pc = getProjCtxt();
            ColumnNames fldList = new ColumnNames();
            var q = from ColumnNames.colInfo fld in fldList.impFields
                    where fld.CustomField == false
                    select fld;
                    
            Console.WriteLine(q.Count());
            foreach(ColumnNames.colInfo dynField in q){
                pc.Load(pc.Projects, p => p.Include(pj => pj[dynField.FieldName]));
            }
            pc.Load(pc.Projects, p => p.Include(pj => pj.IncludeCustomFields));
            pc.ExecuteQuery();
        }
