	[TestClass]
	public class NugetPackagesTest
	{
		/// <summary>
		/// This test method makes sure that we do not install different versions of the same nuget package
		/// across the solution. For example this test will fail if one project references EntityFramework
		/// version 6.1.3 and another project references version 6.2.0. Having different versions of the same
		/// package installed often results in unexpected and hard-to-understand errors.
		/// </summary>
		[TestMethod]
		public void PackagesAccrossProjectsAreOfSameVersion()
		{
			var dir = GetSolutionRoot();
			Debug.Assert(dir != null, nameof(dir) + " != null");
			var filePaths = Directory.GetFiles(dir.FullName, "*packages.config", SearchOption.AllDirectories);
			var installedPackages = filePaths
				.Select(t => new PackageReferenceFile(t))
				.SelectMany(t => t.GetPackageReferences())
				.GroupBy(t => t.Id)
				.ToList();
			foreach (var package in installedPackages)
			{
				var versions = package
					.Select(t => t.Version.ToNormalizedString())
					.Distinct()
					.ToList();
				Assert.IsTrue(
					versions.Count == 1,
					$"Multiple versions of package {package.Key} are installed: {versions.Join(", ")}.");
			}
		}
		private static DirectoryInfo GetSolutionRoot()
		{
			var current = AppDomain.CurrentDomain.BaseDirectory;
			var dir = Directory.GetParent(current);
			while (dir != null)
			{
				// TODO: replace with name your solution's folder.
                if (dir.Name == "MySolution")
				{
					dir = dir.Parent;
					break;
				}
				dir = dir.Parent;
			}
			return dir;
		}
	}
