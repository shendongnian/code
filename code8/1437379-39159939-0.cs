    Product.ToList().ForEach(i => {
    	i.GetType().GetProperties().ToList().ForEach( p =>{
    		p.SetValue(i, p.GetValue(i).ToString().Replace(" ",String.Empty));});
    
    	i.GetType().GetFields().ToList().ForEach( p =>{
    		p.SetValue(i, p.GetValue(i).ToString().Replace(" ",String.Empty));});
    });
