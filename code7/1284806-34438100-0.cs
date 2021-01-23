    public ICollection<MyEfObject> GetObjects() {
        return XmlObject.SubObj.SubObj.SubObj
            .Where(x => x.property != null)
            .Select(x => new MyEfObject { Prop1 = x.property })
            .ToList();
    }
