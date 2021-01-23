    using System.Linq;
    private void Do_FillGrid() {
        var myTagsOut = MyTags.Select(tag => new { id = tag._id, unit = tag._Units, date = tag._PointDate, val = tag._PointValueString, stat = tag._PointStatus }).ToList();
        this.Data_Grid1.AutoGenerateColumns = true;
        this.Data_Grid1.DataSource = myTagsOut;
    }
