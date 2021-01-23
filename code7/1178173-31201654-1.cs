        public static string ValidateSeName<T>(this T entity, string seName, string name, bool ensureNotEmpty)
             where T : BaseEntity, ISlugSupported
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            //use name if sename is not specified
            if (String.IsNullOrWhiteSpace(seName) && !String.IsNullOrWhiteSpace(name))
                seName = name;
            
            //validation
            seName = GetSeName(seName);
            //max length
            //For long URLs we can get the following error:
            //"the specified path, file name, or both are too long. The fully qualified file name must be less than 260 characters, and the directory name must be less than 248 characters"
            //that's why we limit it to 200 here (consider a store URL + probably added {0}-{1} below)
            seName = CommonHelper.EnsureMaximumLength(seName, 200);
            if (String.IsNullOrWhiteSpace(seName))
            {
                if (ensureNotEmpty)
                {
                    //use entity identifier as sename if empty
                    seName = entity.Id.ToString();
                }
                else
                {
                    //return. no need for further processing
                    return seName;
                }
            }
            //ensure this sename is not reserved yet
            string entityName = typeof(T).Name;
            var urlRecordService = EngineContext.Current.Resolve<IUrlRecordService>();
            var seoSettings = EngineContext.Current.Resolve<SeoSettings>();
            int i = 2;
            var tempSeName = seName;
            while (true)
            {
                //check whether such slug already exists (and that is not the current entity)
                var urlRecord = urlRecordService.GetBySlug(tempSeName);
                var reserved1 = urlRecord != null && !(urlRecord.EntityId == entity.Id && urlRecord.EntityName.Equals(entityName, StringComparison.InvariantCultureIgnoreCase));
                //and it's not in the list of reserved slugs
                var reserved2 = seoSettings.ReservedUrlRecordSlugs.Contains(tempSeName, StringComparer.InvariantCultureIgnoreCase);
                if (!reserved1 && !reserved2)
                    break;
                tempSeName = string.Format("{0}-{1}", seName, i);
                i++;
            }
            seName = tempSeName;
            return seName;
        }
