    public class Node
    {
        public List<INodeData> listOutputs()
        {
            var fieldInfos = GetType().GetFields();
            var list = new List<INodeData>();
            foreach (var item in fieldInfos)
            {
                INodeData data = GetType().GetField(item.Name).GetValue(this) as INodeData;
                list.Add(data);    
            }
            return list;
        }
    }
