    public ICollection<MyRowType> RunCommand(Expression<Func<MyRowType,bool>> condition) {
        using (var db = new MyDbContext()) {
            var result = db.MyRowType
                .Include(r => r.RelatedTableA)
                .Include(r => r.RelatedTableB)
                .Include(r => r.RelatedTableC)
                .Where(condition)
                .ToList();
        }
    }
