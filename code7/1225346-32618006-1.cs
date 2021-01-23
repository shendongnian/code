    public IEnumerable<B> GetList(A obj)
    {
        return obj.yTest.Keys.AsParallel().Select(key =>
        {
            switch (key)
            {
                case "1":
                    return new B() {Name = obj.yTest[key]};
                    break;
                case "2":
                    return new B() {Name = obj.yTest[key]};
                    break;
                case "3":
                    return new B() {Name = obj.yTest[key]};
                    break;
                case "4":
                    return new B() {Name = obj.yTest[key]};
                    break;
                default:
                    return new B() {Name = obj.yTest[key]};
                    break;
            }
        });
    }
