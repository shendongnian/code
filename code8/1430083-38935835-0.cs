    Task("Test-xUnit")
        .WithCriteria(() => DirectoryExists(parameters.Paths.Directories.PublishedxUnitTests))
        .Does(() =>
    {
        EnsureDirectoryExists(parameters.Paths.Directories.xUnitTestResults);
        OpenCover(tool => {
            tool.XUnit2(GetFiles(parameters.Paths.Directories.PublishedxUnitTests + "/**/*.Tests.dll"), new XUnit2Settings {
                OutputDirectory = parameters.Paths.Directories.xUnitTestResults,
                XmlReport = true,
                NoAppDomain = true
            });
        },
        parameters.Paths.Files.TestCoverageOutputFilePath,
        new OpenCoverSettings { ReturnTargetCodeOffset = 0 }
            .WithFilter(testCoverageFilter)
            .ExcludeByAttribute(testCoverageExcludeByAttribute)
            .ExcludeByFile(testCoverageExcludeByFile));
    });
