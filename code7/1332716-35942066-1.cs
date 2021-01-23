    Public Sub ReleaseBuild()
       DTE.Solution.SolutionBuild.Clean(True)
       DTE.Solution.SolutionBuild.Build(True)    
    End Sub
    
    Public Sub DebugBuild()
       DTE.Solution.SolutionBuild.Clean(True)
       DTE.Solution.SolutionBuild.Build(True)
    End Sub
