    Public Shared Sub SetFormVisualTheme(ByVal form As Form, ByVal theme As TelerikVisualThemes)
        form.SuspendLayout()
        form.AutoScaleMode = AutoScaleMode.None
        Telerik.WinControls.ThemeResolutionService.ApplyThemeToControlTree(form, theme.ToString)
        form.AutoScaleMode = AutoScaleMode.Font
        form.ResumeLayout()
    End Sub
    Public Enum TelerikVisualThemes As Integer
        AllThemes = 0
        Aqua = 1
        Breeze = 2
        Desert = 4
        Office2007Black = 8
        Office2007Silver = 16
        Office2010Black = 32
        Office2010Blue = 64
        Office2010Silver = 128
        Office2013Light = 256
        Office2013Dark = 512
        TelerikMetro = 1024
        TelerikMetroBlue = 2048
        TelerikMetroTouch = 4096
        VisualStudio2012Light = 8192
        VisualStudio2012Dark = 16384
        Windows7 = 32768
        Windows8 = 65536
    End Enum
