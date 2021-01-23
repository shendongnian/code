    <renderField>
      <processor type="Sitecore.Pipelines.RenderField.SetParameters, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.GetFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.GetTextFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.ExpandLinks, Sitecore.Kernel" />
      <!--<processor type="Sitecore.Pipelines.RenderField.GetImageFieldValue, Sitecore.Kernel" />-->
      <processor type="Custom.Business.SC.Extensions.Pipelines.RenderField.GetFieldValue, Custom.Business" />
      <processor type="Sitecore.Pipelines.RenderField.GetLinkFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.GetInternalLinkFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.GetMemoFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.GetDateFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.GetDocxFieldValue, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.AddBeforeAndAfterValues, Sitecore.Kernel" />
      <processor type="Sitecore.Pipelines.RenderField.RenderWebEditing, Sitecore.Kernel" />
    </renderField>
