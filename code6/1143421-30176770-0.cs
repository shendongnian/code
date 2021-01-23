    DxfFile dxf;
    using (var stream = new FileStream(@"path\to\file.dxf", FileMode.Open))
    {
        dxf = DxfFile.Load(stream);
    }
    foreach (var entity in dxf.Entities)
    {
        switch (entity.EntityType)
        {
            case DxfEntityType.Line:
                var line = (DxfLine)entity;
                // insert code here to add the line to SharpMap using
                // line.P1 and line.P2 as end points
                break;
        }
    }
