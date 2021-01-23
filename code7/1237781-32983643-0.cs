    <Biml xmlns="http://schemas.varigence.com/biml.xsd">
	    <ScriptProjects>
		    <ScriptTaskProject ProjectCoreName="ST_32983202" Name="ST_32983202" VstaMajorVersion="0">
			    <ReadOnlyVariables>
				    <Variable Namespace="User" VariableName="Failure_Reason" DataType="String" />
				    <Variable Namespace="User" VariableName="ErrorLog" DataType="String" />
			    </ReadOnlyVariables>
			    <Files>
				    <File Path="ScriptMain.cs" BuildAction="Compile">using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Runtime;
    using System.Windows.Forms;
    namespace ST_32983202
    {
	    [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
	    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
	    {
		    public void Main()
		    {
		        bool fireAgain = false;
            
                string variableValue = Dts.Variables["Failure_Reason"].Value.ToString();
                string outputFile = Dts.Variables["ErrorLog"].Value.ToString();
                System.IO.File.AppendAllText(outputFile, variableValue);
            
		        string message = variableValue;
			    Dts.Events.FireInformation(0, "variableValue", message, string.Empty, 0, ref fireAgain);
			    Dts.TaskResult = (int)ScriptResults.Success;
		    }
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
	    }
    }				</File>
				    <File Path="Properties\AssemblyInfo.cs" BuildAction="Compile">
    using System.Reflection;
    using System.Runtime.CompilerServices;
    //
    // General Information about an assembly is controlled through the following
    // set of attributes. Change these attribute values to modify the information
    // associated with an assembly.
    //
    [assembly: AssemblyTitle("AssemblyTitle")]
    [assembly: AssemblyDescription("")]
    [assembly: AssemblyConfiguration("")]
    [assembly: AssemblyCompany("")]
    [assembly: AssemblyProduct("ProductName")]
    [assembly: AssemblyCopyright("Copyright @  2015")]
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
				    <AssemblyReference AssemblyPath="System.Windows.Forms" />
				    <AssemblyReference AssemblyPath="System.Xml" />
				    <AssemblyReference AssemblyPath="Microsoft.SqlServer.ManagedDTS.dll" />
				    <AssemblyReference AssemblyPath="Microsoft.SqlServer.ScriptTask.dll" />
			    </AssemblyReferences>
		    </ScriptTaskProject>
	    </ScriptProjects>
	    <Packages>
		    <Package Name="so_32983202" ConstraintMode="Linear">
                <Variables>
                    <Variable DataType="String" Name="Failure_Reason"><![CDATA[There was a failure looking up the Job Number.
    The item that caused the failure was: 
    Line: D
    Quantity: 1
    Footage: 1.166667
    ]]></Variable>
                    <Variable DataType="String" Name="ErrorLog">C:\ssisdata\so_32983202.log</Variable>
                </Variables>
			    <Tasks>
				    <Script ProjectCoreName="ST_32983202" Name="SCR Do Stuff">
					    <ScriptTaskProjectReference ScriptTaskProjectName="ST_32983202" />
				    </Script>
			    </Tasks>
		    </Package>
	    </Packages>
    </Biml>
