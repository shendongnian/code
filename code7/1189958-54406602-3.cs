    private Mock<DbSet<OutgoingEntry>> _set;
    private Mock<MyContext> _context;
    private ModelService<OutgoingEntry, MyContext> _service;
    [NUnit.Framework.SetUp]
    public void Setup()
    {
        _set = new Mock<DbSet<OutgoingEntry>>();
        _set.Reset();
        _context = new Mock<MyContext>();
        _context.Reset();
        _context.Setup(m => m.OutgoingEntries).Returns(_set.Object);
        _context.Setup(m => m.Set<OutgoingEntry>()).Returns(_set.Object);
        _service = new OutgoingService(_context.Object);
    }
