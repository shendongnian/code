    <Biml xmlns="http://schemas.varigence.com/biml.xsd">
      <Connections>
        <Connection
            Name="tempdb"
            ConnectionString="Data Source=.\dev2008;Initial Catalog=tempdb;Provider=SQLNCLI11.1;Integrated Security=SSPI;"
                />
      </Connections>
      <Packages>
        <Package Name="so_31330881">
          <Tasks>
            <Dataflow Name="DFT Sample">
              <Transformations>
                <OleDbSource ConnectionName="tempdb" Name="OLESRC dbo_Source">
                  <DirectInput>SELECT D.MealCode FROM (VALUES ('FREE'), ('free'), ('Free')) AS D(MealCode);</DirectInput>
                </OleDbSource>
                <ScriptComponentTransformation ProjectCoreName="SC_31330881" Name="SCR Transform values">
                  <ScriptComponentProjectReference ScriptComponentProjectName="SC_31330881" />
                </ScriptComponentTransformation>
                <DerivedColumns Name="DER Placeholder" />
              </Transformations>
            </Dataflow>
          </Tasks>
        </Package>
      </Packages>
        <ScriptProjects>
            <ScriptComponentProject ProjectCoreName="SC_31330881" Name="SC_31330881">
        <Files>
            <File Path="main.cs">
    using System;
    using System.Data;
    using System.Web.Services;
    using System.Text;
    using System.Xml;
    using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
    [Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
    public class ScriptMain : UserComponent
    {
        public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
          // if (Row.MealCode.Contains("FREE"))
          if (Row.MealCode.ToUpper().Contains("FREE".ToUpper()))
          {
              Row.tMealCode = "Free";
          }
          else
          {
              Row.tMealCode = "Else";
          }      
        }
    }
    </File>
          <File Path="Properties\AssemblyInfo.cs">
            using System.Reflection;
            using System.Runtime.CompilerServices;
            //
            // General Information about an assembly is controlled through the following
            // set of attributes. Change these attribute values to modify the information
            // associated with an assembly.
            //
            [assembly: AssemblyTitle("SC_31330881")]
            [assembly: AssemblyDescription("")]
            [assembly: AssemblyConfiguration("")]
            [assembly: AssemblyCompany("")]
            [assembly: AssemblyProduct("SC_31330881")]
            [assembly: AssemblyCopyright("Copyright @  2014")]
            [assembly: AssemblyTrademark("")]
            [assembly: AssemblyCulture("")]
            //
            // Version information for an assembly consists of the following four values:
            //
            //      Major Version
            //      Minor Version
            //      Build Number
            //      Revision
            //
            // You can specify all the values or you can default the Revision and Build Numbers
            // by using the '*' as shown below:
            [assembly: AssemblyVersion("1.0.*")]
          </File>
        </Files>
        <AssemblyReferences>
          <AssemblyReference AssemblyPath="System" />
          <AssemblyReference AssemblyPath="System.Data" />
          <AssemblyReference AssemblyPath="System.Web.Services" />
          <AssemblyReference AssemblyPath="System.Windows.Forms" />
          <AssemblyReference AssemblyPath="System.Xml" />
          <AssemblyReference AssemblyPath="Microsoft.SqlServer.TxScript.dll" />
          <AssemblyReference AssemblyPath="Microsoft.SqlServer.DTSRuntimeWrap.dll" />
          <AssemblyReference AssemblyPath="Microsoft.SqlServer.DTSPipelineWrap.dll" />
          <AssemblyReference AssemblyPath="Microsoft.SqlServer.PipelineHost.dll" />
        </AssemblyReferences>
              <InputBuffer Name="Input 0">
                <Columns>
                  <Column CodePage="1252" DataType="AnsiString" Length="10" Name="MealCode" UsageType="ReadOnly" />
                </Columns>
              </InputBuffer>
        <OutputBuffers>
          <OutputBuffer IsSynchronous="true" Name="Output 0">
            <Columns>
              <Column CodePage="1252" DataType="AnsiString" Length="10" Name="tMealCode" />
            </Columns>
          </OutputBuffer>
        </OutputBuffers>
      </ScriptComponentProject>
    </ScriptProjects>
    </Biml>
