    public static class VideoArbitrary
    {
        public static Arbitrary<Video> Videos()
        {
            var genVideo = from w in Arb.Generate<PositiveInt>()
                           from h in Arb.Generate<PositiveInt>()
                           from arrs in Gen.ListOf(
                               Gen.Array2DOf<int>(
                                   h.Item,
                                   w.Item,
                                   Arb.Generate<int>()))
                           select new Video(w.Item, h.Item, arrs);
            return genVideo.ToArbitrary();
        }
    }
