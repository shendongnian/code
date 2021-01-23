    public class DataBlock<T> : BaseBlock where T : BaseField {
        ...
        private T _Field;
        public DataBlock(string name, T field): base(name, E_BlockType.Data) 
        {
            _Field = field;            
        }
    }
