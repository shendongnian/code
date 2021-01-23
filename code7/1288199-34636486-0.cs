    [Route("olderthan/{lastupdate}")]
            public IQueryable<FirearmDto> GetFirearmsByDateolderthan(DateTime lastupdate)
            {
                return db.Firearms
                    .Where(f => f.LastUpdate < lastupdate)
                    .Select(AsFirearmDto);
            }
