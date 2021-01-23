    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDataContext _context;
        public UnitOfWork(IDataContext context,IKullaniciDal kullaniciDal,IKategoriDal kategoriDal, IUrunDal urunDal)
        {
            KullaniciDal = kullaniciDal;
            KategoriDal = kategoriDal;
            UrunDal = urunDal;
            _context = context;
        }
    
        public IKategoriDal KategoriDal{get;private set;}
    
        public IKullaniciDal KullaniciDal{get;private set;}
    
        public IUrunDal UrunDal{get;private set;}
    
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
