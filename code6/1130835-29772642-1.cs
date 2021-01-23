    public class daoClass {
        public Product p {get; set;}
        public Int32 cs {get; set;}
    }
    IEnumerable<Int32> lis = prodParamCritria.Select(x => x.CodeProductParamId).ToList();
	var q = Products.Select(
			x => new daoClass { 
				p = x,
				cs = x.ProductParams.Where(y => lis.Contains(y.Id))
			}
		).Where(y => y.cs.Count() == lis.Count()).
	    SelectMany(y => y.p).
		ToList();
