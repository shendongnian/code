    git diff
    diff --git a/MonoApi.csproj b/MonoApi.csproj
    index b6fc96f..93f670c 100644
    --- a/MonoApi.csproj
    +++ b/MonoApi.csproj
    @@ -66,14 +66,14 @@
         <HintPath>packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>
       </Reference>
       <Reference Include="System.Net.Http.Formatting">
    -    <HintPath>packages\Microsoft.AspNet.WebApi.Client.5.2.2\lib\net45\System.Net.Http.Formatting.dll</HintPath>
    +    <HintPath>packages\Microsoft.AspNet.WebApi.Client.4.0.30506\lib\net40\System.Net.Http.Formatting.dll</HintPath>
       </Reference>
       <Reference Include="System.Net.Http" />
       <Reference Include="System.Web.Http">
    -    <HintPath>packages\Microsoft.AspNet.WebApi.Core.5.2.2\lib\net45\System.Web.Http.dll</HintPath>
    +    <HintPath>packages\Microsoft.AspNet.WebApi.Core.4.0.30506\lib\net40\System.Web.Http.dll</HintPath>
       </Reference>
       <Reference Include="System.Web.Http.WebHost">
    -    <HintPath>packages\Microsoft.AspNet.WebApi.WebHost.5.2.2\lib\net45\System.Web.Http.WebHost.dll</HintPath>
    +    <HintPath>packages\Microsoft.AspNet.WebApi.WebHost.4.0.30506\lib\net40\System.Web.Http.WebHost.dll</HintPath>
       </Reference>
       </ItemGroup>
       <ItemGroup>
    diff --git a/Controllers/PersonController.cs b/Controllers/PersonController.cs
    index a9c79f0..8a58974 100644
    --- a/Controllers/PersonController.cs
    +++ b/Controllers/PersonController.cs
    @@ -25,7 +25,8 @@ namespace MonoApi.Controllers
        Person person = databasePlaceholder.Get(id);
        if (person == null)
        {
    -       throw new HttpResponseException(HttpStatusCode.NotFound);
    +       // HttpStatusCode method not implemenent on mono https://github.com/mono/aspnetwebstack/blob/current/src/System.Web.Http/HttpResponseException.cs
    +       throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        return person;
      }
