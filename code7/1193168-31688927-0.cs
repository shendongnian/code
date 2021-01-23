    using FlatFiles;
    using FlatFiles.TypeMapping;
    
    public class FixedWidthDataSource<FixedWidthRecordT> {
        public IFixedLengthTypeConfiguration<FixedWidthRecordT> Configuration
            = FixedLengthTypeMapper.Define<FixedWidthRecordT>()
        ;
        public IFixedLengthTypeMapper<FixedWidthRecordT> Mapper;
        public FixedWidthDataSource() {
            Mapper = (IFixedLengthTypeMapper<FixedWidthRecordT>)Configuration;
        }
        ...
        public void MapProperty<T>(
            Expression<Func<FixedWidthRecordT, T>> col
            , int width
            , string inputFormat = null
        ) {
            var window = new Window(width);
            Configuration.Property((dynamic)col, window);
        }
    }
    
    public class FixedWidthRecord
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
    
    //later
    var fwds = new FixedWidthDataSource<FixedWidthRecord>();
    fwds.MapProperty(c=>c.First, 5);
