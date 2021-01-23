    public void DeleteB(int bId)
    {
        var entity = _context.Bs.Single(b => b.Id == bId);
        _context.Entry(entity).Collection(b => b.As).Load(); 
        _context.Bs.Remove(entity);
        _context.SaveChanges();
    }
