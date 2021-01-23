    public IEnumerable<BegrotingsVoorstel> getVoorstelVanProject(int id)
    {
        var help = ctx.BegrotingsVoorstellen.Where(b => b.ProjectId == id);
        foreach(BegrotingsVoorstel voorstel in help)
        {
            var medias = ctx.BegrotingsVoorstelMedias
                .Where(c => c.BegrotingsVoorstelId == voorstel.BegrotingsVoorstelId); 
            voorstel.BegrotingsVoorstelMedia = voorstel.BegrotingsVoorstelMedia.Concat(medias).ToList();
        }
        return help;
    }
