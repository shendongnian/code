    #region Assembly Microsoft.AspNetCore.Mvc.Core, Version=2.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
    // C:\Users\BhailDa\.nuget\packages\microsoft.aspnetcore.mvc.core\2.0.0\lib\netstandard2.0\Microsoft.AspNetCore.Mvc.Core.dll
    #endregion
    
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Net.Http.Headers;
    
    namespace Microsoft.AspNetCore.Mvc
    {
        //
        // Summary:
        //     A base class for an MVC controller without view support.
        [Controller]
        public abstract class ControllerBase
        {
            protected ControllerBase();
    
            //
            // Summary:
            //     Gets the System.Security.Claims.ClaimsPrincipal for user associated with the
            //     executing action.
            public ClaimsPrincipal User { get; }
