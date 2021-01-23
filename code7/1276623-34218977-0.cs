        // <summary>
        // check that the compiler is in a build mode that enables documentation analysis.
        // it's not clear when this is off, but command line builds, and full rebuilds
        // seem to have it turned off from time to time.
        // </summary>
        internal static bool IsDocumentationModeOn(this SyntaxNodeAnalysisContext context)
        {
            return context.Node.SyntaxTree?.Options.DocumentationMode 
                   != DocumentationMode.None;
        }
