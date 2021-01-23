    public class Model1FixVisitor
    {
        public MyModel1 Visit(MyModel1 model)
        {
            model.Name = new StringFixVisitor().Visit(model.Name);
            model.Surname = new StringFixVisitor().Visit(model.Surname);
            model.Address = new ClientAddressFixVisitor().Visit(model.Address);
            return model;
        }
    }
    public class Model2FixVisitor
    {
        public MyModel2 Visit(MyModel2 model)
        {
            model.CompanyName = new StringFixVisitor().Visit(model.CompanyName);
            model.Region = new StringFixVisitor().Visit(model.Region);
            model.Address = new CompanyAddressFixVisitor().Visit(model.Address);
            return model;
        }
    }
    public class ClientAddressFixVisitor
    {
        public ClientAddress Visit(ClientAddress address)
        {
            address.Line1 = new StringFixVisitor().Visit(address.Line1);
            address.Line2 = new StringFixVisitor().Visit(address.Line2);
            address.Line3 = new StringFixVisitor().Visit(address.Line3);
            return address;
        }
    }
    public class CompanyAddressFixVisitor
    {
        public CompanyAddress Visit(CompanyAddress address)
        {
            address.Line1 = new StringFixVisitor().Visit(address.Line1);
            address.Line2 = new StringFixVisitor().Visit(address.Line2);
            address.AdditionalLines = new StringListFixVisitor().Visit(address.AdditionalLines);
            return address;
        }
    }
    public class StringFixVisitor
    {
        public string Visit(string element)
        {
            return element.Replace("mistake", "correction");
        }
    }
    public class StringListFixVisitor
    {
        public List<string> Visit(List<string> elements)
        {
            return elements
                .Select(x => new StringFixVisitor().Visit(x))
                .ToList();
        }
    }
