    try
    {
        // 13.0.2000.0 is Crystal Reports for VS 2010
        // the first assembly is the most important one, but it also gets deployed by the project itself
        // because of this I picked two additional assemblies to check for
        var a = System.Reflection.Assembly.Load("CrystalDecisions.CrystalReports.Engine, Version=13.0.2000.0, Culture=neutral,PublicKeyToken=692fbea5521e1304");
        result = a != null;
        a = System.Reflection.Assembly.Load("CrystalDecisions.CrystalReports.TemplateEngine, Version=13.0.2000.0, Culture=neutral,PublicKeyToken=692fbea5521e1304");
        result &= a != null;
        a = System.Reflection.Assembly.Load("CrystalDecisions.Windows.Forms, Version=13.0.2000.0, Culture=neutral,PublicKeyToken=692fbea5521e1304");
        result &= a != null;
    }
    catch (FileNotFoundException ex)
    {
        this.LogAction("Could not open the report. To view it, you need to have Crystal Reports v13.0.12 (32-bit only) installed.");
        result = false;
    }
    catch
    {
        //Runtime is in GAC but something else prevents it from loading. (bad install?, etc)
        result = false;
    }
