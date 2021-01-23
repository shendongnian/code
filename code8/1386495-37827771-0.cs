      <pipelines>
          <mvc.exception>
            <processor type="Sitecore.Mvc.Pipelines.MvcEvents.Exception.ShowAspNetErrorMessage, Sitecore.Mvc">
              <patch:attribute name="type">Northwestern.Core.Infrastructure.Pipelines.ExceptionErrorHandler, Northwestern.Core</patch:attribute>
            </processor>
          </mvc.exception>
        </pipelines>
