    // this interface is public, and it allows everyone to read
    public interface IMetadataColumns
    {
        Int32 Id { get; }
    }
    
    // this one is writeable, but it's internal
    internal interface IMetadataColumnsWritable : IMetadataColumns
    {
        new Int32 Id { get; set; }
    }
    
    // internal implementation is writeable, but you can pass it 
    // to other assemblies through the readonly IMetadataColumns 
    // interface
    internal class MetadataColumns : IMetadataColumnsWritable
    {
        public Int32 Id { get; set; }
    }
