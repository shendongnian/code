    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;   
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<ImportedType> sp1 = new List<ImportedType>();
                List<DissolutionType> sp2 = new List<DissolutionType>();
                sp1.AddRange( new ImportedType[]{new ImportedType() { Imported = 2, Period = "2024-02" }, new ImportedType() { Imported = 2, Period = "2014-11" }, new ImportedType() { Imported = 2, Period = "2024-12" }});
                sp2.AddRange(new DissolutionType[] { new DissolutionType() { Dissolution = 2, Period = "2024-02" }, new DissolutionType() { Dissolution = 2, Period = "2034-02" }, new DissolutionType() { Dissolution = 2, Period = "2024-12" } });    
                var  r1 = (from x in sp1
                                   select new
                                   {
                                       x.Imported,
                                       x.Period
                                   }).ToList<object>();
                var r2 = (from x in sp2
                                   select new
                                   {
                                       x.Dissolution,
                                       x.Period
                                   }).ToList<object>();                
                var r3 = r1.Concat(r2).Except(r1.Where(res =>
                    {    
                        object vp2 = r2.SingleOrDefault(res2 => GetValue(res2) == GetValue(res));
                        if (vp2!=null)
                        {
                            return true; 
                        }    
                        return false;
                    }));        
            }
    
            private static object GetValue(object res)
            {
                Type t = res.GetType();
                PropertyInfo p = t.GetProperty("Period");
                object v = p.GetValue(res, null);
                return v; 
            }
        }
    }
