	<#@ assembly name="System.Configuration" #>
	<#@ assembly name="EnvDTE" #>
	<#@ assembly name="System.Core.dll" #>
	<#@ import namespace="System" #>
	<#@ import namespace="System.Configuration" #>
	<#@ import namespace="System.Text.RegularExpressions" #>
	<#+
> 	 
	/// <summary>
	/// Provides strongly typed access to the hosting EnvDTE.Project and app.config/web.config
	/// configuration file, if present.
	///
	/// Typical usage from T4 template:
	/// <code>ConfigurationAccessor config = new ConfigurationAccessor((IServiceProvider)this.Host);</code>
	///
	/// </summary>
	/// <author>Sky Sanders [sky.sanders@gmail.com, http://skysanders.net/subtext]</author>
	/// <date>01-23-10</date>
	/// <copyright>The contents of this file are a Public Domain Dedication.</copyright>
	///
	/// TODO: determine behaviour of ProjectItem.FileNames when referred to a linked file.
	///
	public class ConfigurationAccessor
	{
