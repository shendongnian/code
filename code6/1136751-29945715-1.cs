    namespace Microsoft.Internal.VisualStudio.Shell.Interop
    {
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0D915B59-2ED7-472A-9DE8-9161737EA1C5")]
        public interface SVsColorThemeService
        {
        }
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("EAB552CF-7858-4F05-8435-62DB6DF60684")]
        public interface IVsColorThemeService {
            void _VtblGap1_4();
            IVsColorThemes Themes { [return: MarshalAs(UnmanagedType.Interface)] get; }
            IVsColorNames ColorNames { [return: MarshalAs(UnmanagedType.Interface)] get; }
            IVsColorTheme CurrentTheme { [return: MarshalAs(UnmanagedType.Interface)] get; }
        }
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("98192AFE-75B9-4347-82EC-FF312C1995D8")]
        public interface IVsColorThemes {
            [return: MarshalAs(UnmanagedType.Interface)]
            IVsColorTheme GetThemeFromId([In] Guid ThemeId);
        }
        [ComImport, Guid("413D8344-C0DB-4949-9DBC-69C12BADB6AC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IVsColorTheme {
            void _VtblGap1_1();
            IVsColorEntry this[ColorName Name] { [return: MarshalAs(UnmanagedType.Interface)] get; }
            Guid ThemeId { get; }
        }
        [ComImport, TypeIdentifier, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BBE70639-7AD9-4365-AE36-9877AF2F973B")]
        public interface IVsColorEntry {
            ColorName ColorName { get; }
            byte BackgroundType { get; }
            byte ForegroundType { get; }
            uint Background { get; }
            uint Foreground { get; }
        }
        public struct ColorName {
            public Guid Category;
            [MarshalAs(UnmanagedType.BStr)]
            public string Name;
        }
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92144F7A-61DE-439B-AA66-13BE7CDEC857")]
        public interface IVsColorNames {
            void _VtblGap1_2();
            int Count { get; }
            System.Collections.IEnumerator GetEnumerator();
        }
    }
