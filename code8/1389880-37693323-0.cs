    public class BankItem
    {
        public int Stacks { get; set; }
        public string Name { get; set; }
        public BankItem(string name, int stacks)
        {
            Name = name;
            Stacks = stacks;
        }
    }
    
    public class BankItemList
    {
        private List<BankItem> bankItems = new List<BankItem>();
    
        public void AddItem(string name, int stacks)
        {
            BankItem i = bankItems.FirstOrDefault(bi => bi.Name == name);
            if(i != null)
                i.Stacks += stacks;
            else
                bankItems.Add(new BankItem(name, stacks));
        }
    
        public void RemoveItem(BankItem i)
        {
            bankItems.Remove(i);
        }
    }
