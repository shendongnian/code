    public override IQueryable<PostcodePrefixRatingMAP> onBeforeFinalSelect(IQueryable<PostcodePrefixRatingMAP> results)
    {
        return base.onBeforeFinalSelect(results)
            .Include(x => x.PostcodePrefix).AsNoTracking()
            .Include(x => x.Rating.RatingType).AsNoTracking()
            .Include(x => x.Rating).AsNoTracking();
    }
