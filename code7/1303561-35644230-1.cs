        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Markup;
    namespace WPFLocalizationSample
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ResourceDictionary CurrentLanguageDictionary;
        private static string LanguageResourceFile = "en-US.xaml";
        private Dictionary<string, System.Windows.Controls.TextBox> TextBoxControls = new Dictionary<string, TextBox>();
        public MainWindow()
        {
            InitializeComponent();
            AddControlsToLocalization();
        }
        private void AddControlsToLocalization()
        {
            TextBoxControls.Add("tbName", tbNameLoc);
            TextBoxControls.Add("btnAdd", btnAddLoc);
        }
        public static bool SaveLanguageFile(Dictionary<string, System.Windows.Controls.TextBox> TextBoxControls, string selectedLang)
        {
            bool status = false;
            try
            {
                using (var fs = new FileStream(LanguageResourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // Read in ResourceDictionary File
                    CurrentLanguageDictionary = (ResourceDictionary)XamlReader.Load(fs);
                }
               
                foreach (string key in TextBoxControls.Keys)
                {
                    TextBox txt = TextBoxControls[key];
                    if (txt.Text.Length > 0)
                    {
                        CurrentLanguageDictionary[key] = txt.Text;
                    }
                }
                using (var writer = new StreamWriter(LanguageResourceFile))
                {
                    XamlWriter.Save(CurrentLanguageDictionary, writer);
                }
                status = true;
            }
            catch (Exception _exception)
            {
                MessageBox.Show("Exception in language file edit");
                return false;
            }
            SetLanguageResourceDictionary(LanguageResourceFile, App.Current);
            return status;
        }
        public static void SetLanguageResourceDictionary(String inFile, Application application)
        {
            if (File.Exists(inFile))
            {
                // Read in ResourceDictionary File
                var languageDictionary = new ResourceDictionary();
                languageDictionary.Source = new Uri(inFile,UriKind.Relative);
                // Remove any previous Localization dictionaries loaded
                int langDictId = -1;
                for (int i = 0; i < application.Resources.MergedDictionaries.Count; i++)
                {
                    var md = application.Resources.MergedDictionaries[i];
                    // Make sure your Localization ResourceDictionarys have the ResourceDictionaryName
                    // key and that it is set to a value starting with "Loc-".
                    if (md.Contains("ResourceDictionaryName"))
                    {
                        if (md["ResourceDictionaryName"].ToString().Equals("en-US"))
                        {
                            langDictId = i;
                            break;
                        }
                    }
                }
                if (langDictId == -1)
                {
                    // Add in newly loaded Resource Dictionary
                    application.Resources.MergedDictionaries.Add(languageDictionary);
                }
                else
                {
                    // Replace the current langage dictionary with the new one
                    application.Resources.MergedDictionaries[langDictId] = languageDictionary;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveLanguageFile(TextBoxControls, "en-US");
        }
    }
    }
