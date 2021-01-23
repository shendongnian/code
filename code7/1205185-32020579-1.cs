    var result = DbContext.ChartingData.Select(x => new PartialDto {
                   Property1 = x.Column1,
                   Property50 = x.Column50,
                   Property109 = x.Column109
                 });
