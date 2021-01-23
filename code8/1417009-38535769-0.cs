    namespace Todiste.Views.Proyectos.NewProjectWizard
    {
    public partial class NewProjectStep1View : UserControl, INewProjectWizardStep
    {
    public void OnStepLoaded()
    {
        ProjectWizardProgressBar progressBar = new ProjectWizardProgressBar();
        progressBar.test = "This is an updated test text";    
    }
    ...
    }
