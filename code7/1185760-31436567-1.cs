    #>
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    //line 46 of SampleEDMX.Context.tt
    using Sample.Shared; //I added this using to fix the build
    <#
    if (container.FunctionImports.Any())
    {
    #>
