	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using MMU.Domain.Extensions;
	using NuGet;
	[TestClass]
	public class NugetPackagesTest
	{
		private readonly Dictionary<string, List<string>> installedPackages = new Dictionary<string, List<string>>();
		/// <summary>
		/// This test method makes sure that we do not install different versions of the same NuGet package
		/// across the solution. For example this test will fail if one project references EntityFramework
		/// version 6.1.3 and another project references version 6.2.0. Having different versions of the same
		/// package installed often results in unexpected and hard-to-understand errors.
		/// </summary>
		[TestMethod]
		public void PackagesAccrossProjectsAreOfSameVersion()
		{
			var current = AppDomain.CurrentDomain.BaseDirectory;
			var dir = Directory.GetParent(current);
			while (dir != null)
			{
                // TODO: replace with the name of your solution's folder.
				if (dir.Name == "MySolution")
				{
					dir = dir.Parent;
					break;
				}
				dir = dir.Parent;
			}
			Debug.Assert(dir != null, nameof(dir) + " != null");
			var files = Directory.GetFiles(dir.FullName, "*packages.config", SearchOption.AllDirectories);
			foreach (var file in files)
			{
				var packagesConfigFile = new PackageReferenceFile(file);
				foreach (var package in packagesConfigFile.GetPackageReferences())
				{
					var list = this.installedPackages.ContainsKey(package.Id)
						? this.installedPackages[package.Id]
						: new List<string>();
					if (!list.Contains(package.Version.ToNormalizedString()))
					{
						list.Add(package.Version.ToNormalizedString());
					}
					this.installedPackages[package.Id] = list;
				}
			}
			foreach (var installedPackage in this.installedPackages)
			{
				Assert.IsTrue(
					installedPackage.Value.Count == 1,
					$"Multiple versions of package {installedPackage.Key} are installed: {installedPackage.Value.Join(", ")}.");
			}
		}
	}
