    var a = 1;
    var result = session.GetNamedQuery("ddd")
                .SetInt32("Data", a)
                .SetResultTransformer(Transformers.AliasToBean<aaa>())
                .UniqueResult<aaa>();  
